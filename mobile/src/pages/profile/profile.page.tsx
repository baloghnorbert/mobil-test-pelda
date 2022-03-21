import React, { useState, useEffect, useContext, useCallback } from "react";
import { IonPage, IonHeader, IonContent, IonCard, IonCardHeader, IonCardTitle, IonCardSubtitle, IonCardContent, IonFooter, IonItem, IonIcon, NavContext} from "@ionic/react";
import { Player } from "./../../client/client";
import { withRouter, RouteComponentProps } from "react-router-dom";
import { WebAPI } from "./../../service/webAPI";
import { createOutline } from "ionicons/icons";

interface IProps extends RouteComponentProps<{id: string}>
{}

const ProfilePage: React.FC<IProps> = (props: IProps): JSX.Element =>
{
    const [player, setPlayer] = useState<Player>();

    const { navigate } = useContext(NavContext);
    const redirectToUpdatePage = useCallback(() => navigate(`/update/${props.match.params.id}`, "forward"), [navigate]);

    useEffect(() =>
    {
        fetchData()
    }, []);

    const fetchData = async (): Promise<void> =>
    {
        const id: number = +props.match.params.id;
        const data: Player | undefined = await WebAPI.Players.get(id);
        setPlayer(data);
    }

    const onEdit = async (): Promise<void> =>
    {
        redirectToUpdatePage();
    }

    return (
    <IonPage>
        <IonHeader className="flex center">
            <IonItem lines="none">Amazons of Volleyball</IonItem>
        </IonHeader>
        <IonContent fullscreen>
            <IonCard>
                <img src={player?.imageLink} alt={player?.name} />
                <IonCardHeader>
                    <IonCardTitle>{player?.name}</IonCardTitle>
                    <IonCardSubtitle>{player?.club}</IonCardSubtitle>
                </IonCardHeader>
                <IonCardContent>
                    <p>{player?.description}</p>
                    <hr />
                    <p><b>Születési dátum:</b>{player?.birthday}</p>
                    <hr />
                    <p><b>Súly:</b>{player?.weight} kg</p>
                    <p><b>Magasság:</b>{player?.height} m</p>
                    <hr />
                </IonCardContent>
            </IonCard>
        </IonContent>
        <IonFooter>
            <IonItem>
                <IonIcon icon={createOutline} slot="end" color="primary" onClick={() => onEdit()} />
            </IonItem>
        </IonFooter>
    </IonPage>
    );
}

export default withRouter(ProfilePage);