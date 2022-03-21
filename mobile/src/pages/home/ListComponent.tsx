import React from 'react';
import { IonItem, IonAvatar, IonLabel, IonItemSliding, IonItemOptions, IonItemOption, IonIcon } from '@ionic/react';
import { Player } from './../../client/client';
import { trashOutline} from "ionicons/icons";

interface IProps
{
    player: Player;
    onDelete: (id: number) => void;
}

const ListComponent: React.FC<IProps> = (props: IProps): JSX.Element =>
{
    const onDelete = async (): Promise<void> =>
    {
        props.onDelete(props.player.id!);
    }

    return (
    <IonItemSliding>
        <IonItem routerLink={`/profile/${props.player.id}`}>
            <IonAvatar slot="start">
                <img src={props.player.imageLink} alt={props.player.name} />
            </IonAvatar>
            <IonLabel>
                <h2>{props.player.name}</h2>
                <h3>{props.player.club}</h3>
                <p>{props.player.description}</p>
            </IonLabel>
        </IonItem>
        <IonItemOptions side='end'>
            <IonItemOption onClick={() => onDelete()}
                           color="danger">
                <IonIcon icon={trashOutline} color="light"/>
            </IonItemOption>
        </IonItemOptions>
    </IonItemSliding>
    );
}

export default ListComponent;