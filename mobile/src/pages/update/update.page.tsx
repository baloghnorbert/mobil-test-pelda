import react, {useState,useCallback, useEffect, useContext} from "react";
import { useForm } from "react-hook-form";
import { Player, PlayerRequest, Position } from "./../../client/client";
import { validationSchema } from "./validation";
import { yupResolver } from "@hookform/resolvers/yup";
import { WebAPI } from "./../../service/webAPI";
import { IonButton, IonCol, IonContent, IonGrid, IonHeader, IonItem, IonPage, IonRow, NavContext } from "@ionic/react";
import Loader from "react-loader-spinner";
import HookFormDateTimePicker from "../../library/hooksFormControlls/components/hookFormDateTimePicker";
import HookFormTextBox from "./../../library/hooksFormControlls/components/hookFomTextBox";
import { PositionSelectList } from "../../library/hooksFormControlls/components/hookFormSelectlist";
import HookFormTextArea from "../../library/hooksFormControlls/components/hookFomTextArea";
import { RouteComponentProps, withRouter } from "react-router-dom";

interface IProps extends RouteComponentProps<{id: string}>
{}

const UpdatePage: React.FC<IProps> = (props: IProps): JSX.Element =>
{
    const [positions, setPoistions] = useState<Position[]>([]);
    const [player, setPlayer] = useState<Player>();
    const [isLoading, setIsLoading] = useState<boolean>(true);

    const {control, handleSubmit, formState: {errors}, formState, reset} = useForm<Player>
    ({
        mode: "onChange",
        resolver: yupResolver(validationSchema)
    });

    const { navigate } = useContext(NavContext);
    const redirectToHomePage = useCallback(() => navigate("/home", "forward"), [navigate]);

    useEffect(() =>
    {
        fetchData();
    }, []);

    const fetchData = async (): Promise<void> =>
    {
        const positionResponse: Position[] = await WebAPI.Positions.getAll();
        setPoistions(positionResponse);

        const id: number = +props.match.params.id;
        const data: Player | undefined = await WebAPI.Players.get(id);
        setPlayer(data);

        await insertData(data);

        setIsLoading(false);
    }

    const insertData = async(data: Player): Promise<void> =>
    {
        reset({
            name: data.name,
            imageLink: data.imageLink,
            club: data.club,
            birthday: data.birthday,
            weight: data.weight,
            height: data.height,
            description: data.description,
            positionId: data.positionId
        });
    }

    const onSubmit = async (data: Player): Promise<void> =>
    {
        data.id = player!.id;
        const response: Player = await WebAPI.Players.update(data)

        if(response)
        {
            redirectToHomePage();
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

    const form = (): JSX.Element =>
    <IonGrid>
        <form onSubmit={handleSubmit((data: Player) => onSubmit(data))}>
            <HookFormTextBox name="name"
                              label="Name"
                              type="text"
                              control={control} 
                              errors={errors} />
            <HookFormTextBox name="imageLink"
                              label="Image Link"
                              type="text"
                              control={control} 
                              errors={errors} />
            <HookFormTextBox name="club"
                              label="Club"
                              type="text"
                              control={control} 
                              errors={errors} />
            <HookFormDateTimePicker name="birthday"
                                    label="Birthday"
                                    endDate={new Date()}
                                    control={control}
                                    errors={errors} />
            <HookFormTextBox name="weight"
                              label="Weight"
                              type="number"
                              control={control} 
                              errors={errors} />
            <HookFormTextBox name="height"
                              label="Height"
                              type="number"
                              control={control} 
                              errors={errors} />
            <PositionSelectList name="positionId"
                                label="Position" 
                                control={control}
                                errors={errors}
                                data={positions}
                                valueMember={(field: Position) => field.id.toString()} 
                                displayMember={(field: Position) => field.name} />
            <HookFormTextArea name="description"
                              label="Description"
                              rows={10}
                              autoGrow={true}
                              control={control} 
                              errors={errors} />
            <IonRow>
                <IonCol>
                    <IonButton expand="block" type="submit" className="ion-margin-top"
                               disabled={!formState.isValid}>
                        MENTÉS
                    </IonButton>
                </IonCol>
            </IonRow>            
        </form>
    </IonGrid>

    return (
    <IonPage>
        <IonHeader className="flex center">
            <IonItem lines="none">Amazons of Volleyball</IonItem>
        </IonHeader>
        <IonContent fullscreen>
        {
          isLoading ? loader() : form() 
        }
        </IonContent>
    </IonPage>
    );
}

export default withRouter(UpdatePage);