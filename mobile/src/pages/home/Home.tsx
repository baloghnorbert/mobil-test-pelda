import './Home.css';

import React, { useState, useEffect, useContext, useCallback } from 'react';
import { IonContent, IonPage, IonList, IonHeader, IonInfiniteScroll, IonInfiniteScrollContent, IonFooter, IonIcon, IonItem, NavContext } from '@ionic/react';
import ListComponent from './ListComponent';
import Loader from "react-loader-spinner";
import { Player } from './../../client/client';
import { WebAPI } from './../../service/webAPI';
import { addCircleOutline } from 'ionicons/icons';

const HomePage: React.FC = () =>
{
  const [players, setPlayers] = useState<Player[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [page, setPage] = useState<number>(0);
  const [disableInfiniteScroll, setDisableInfiniteScroll] = useState<boolean>(false);

  const { navigate } = useContext(NavContext);
  const redirectToCreatePage = useCallback(() => navigate("/create", "forward", "replace"), [navigate]);

  useEffect(() =>
  {
    fetchData();
    setTimeout(() =>
    {
      setIsLoading(false);
    }, 500);
    
  }, []);

  const fetchData = async (): Promise<void> =>
  {
    const playersData: Player[] = await WebAPI.Players.page(page);

    if(playersData && playersData.length > 0)
    {
      setPlayers([...players, ...playersData]);

      if(playersData.length < 10)
      {
        setDisableInfiniteScroll(true);
      }
      else
      {
        setPage(page + 1);
      }
    }
    else
    {
      setDisableInfiniteScroll(true);
    }
  }

  const searchNext = async(e: CustomEvent<void>): Promise<void> =>
  {
    await fetchData();
    (e.target as HTMLIonInfiniteScrollElement).complete();
  }

  const onDelete = async (id: number): Promise<void> =>
  {
      const response: boolean = await WebAPI.Players.delete(id);

      if(response)
      {
        setPlayers(players.filter((x: Player) => x.id !== id));
      }
  }

  const loader = (): JSX.Element =>
  <div className="loader">
    <Loader type="Puff"
            color="#00BFFF"
            height={100}
            width={100}
            visible={isLoading}
    />
  </div>

  const list = (): JSX.Element =>
  <React.Fragment>
    <IonList>
    {
      players.map((player: Player, index: number) =>
        <ListComponent player={player} key={index}
                       onDelete={(id: number) => onDelete(id)}/>
      )
    }
    </IonList>
    <IonInfiniteScroll threshold='0px'
                       disabled={disableInfiniteScroll}
                       onIonInfinite={(e: CustomEvent<void>) => searchNext(e)}>
      <IonInfiniteScrollContent loadingSpinner='bubbles' loadingText='További játékosok betöltése ...'>
      </IonInfiniteScrollContent>
    </IonInfiniteScroll>
  </React.Fragment>

  return (
    <IonPage>
      <IonHeader className="flex center">
        <IonItem lines="none">Amazons of Volleyball</IonItem>
      </IonHeader>
      <IonContent fullscreen>
      {
        isLoading ? loader() : list() 
      }
      </IonContent>
      <IonFooter>
        <IonItem>
          <IonIcon slot="end" icon={addCircleOutline}
                   title="Add new player"
                   color="primary"
                   onClick={() => redirectToCreatePage()}/>
        </IonItem>
      </IonFooter>
    </IonPage>
  );
};

export default HomePage;
