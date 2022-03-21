import { IonGrid, IonRow, IonCol, IonIcon, IonText } from "@ionic/react";
import { imageOutline } from "ionicons/icons";
import React from "react";

interface IProps
{
    onClick: (e: React.FormEvent<HTMLInputElement>) => void;
}

const ImageSelectroComponent:React.FC<IProps> = (props: IProps): JSX.Element =>
{
    const onSelection = (e: React.FormEvent<HTMLInputElement>): void =>
    {
        props.onClick(e);
    }

    return(
        <IonGrid>
            <IonRow>
                <IonCol sizeXs="10">
                    <IonText>Kép kiválasztása</IonText>
                </IonCol>
                <IonCol sizeXs="2">
                    <input accept="image/*" style={{ display: 'none'}} id="icon-button-file" type="file"
                        onChangeCapture={ (e: React.FormEvent<HTMLInputElement>) => onSelection(e)} />
                        <label htmlFor="icon-button-file">
                            <IonIcon aria-label="upload picture" icon={imageOutline}/>
                            </label>
                </IonCol>
            </IonRow>
        </IonGrid>
    );
}

export default ImageSelectroComponent;
