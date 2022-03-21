import "./../styles/main.css"

import { IonItem, IonLabel, IonInput, IonText, IonGrid, IonCol, IonRow } from "@ionic/react";
import React from "react";
import { Controller } from "react-hook-form";
import { InputType } from "../types/InputType";
import { IBaseProps } from "../interfaces/BaseProps";
import { InputValueType } from "./../types/InputValueType";

export interface IHookFormTextBoxProps extends IBaseProps
{
    label: string;
    type: InputType;
    value?: InputValueType
}

const HookFormTextBox: React.FC<IHookFormTextBoxProps> = (props: IHookFormTextBoxProps): JSX.Element =>
{
    return (
    <IonGrid>
        <IonRow>
            <IonCol>
                <IonLabel position="floating" class="label">{props.label}</IonLabel>
                <Controller name={props.name}
                            control={props.control}
                            defaultValue={props.defaultValue}
                            render={ ({field}) =>
                                <IonInput aria-invalid={props.errors && props.errors[props.name] ? "true" : "false"}
                                        aria-describedby={`${props.name}Error`}
                                        type={props.type}
                                        onIonChange={(e) => field.onChange(e)}
                                        onIonBlur={(e) => field.onBlur()}
                                        value={field.value}
                                        disabled={props.disabled ? props.disabled : false}
                                        step="any"
                                        className="input-field" />
                            }
                />
        </IonCol>
        </IonRow>
        <IonRow>
            <IonCol>
            {
                props.errors && props.errors[props.name] &&
                (
                    <IonText color="danger" className="ion-padding-start">
                        <small>
                            <span role="alert" id={`${props.name}Error`}>
                                {props.errors[props.name].message}
                            </span>
                        </small>
                    </IonText>
                )
            }
            </IonCol>
        </IonRow>
    </IonGrid>
    );
}

export default HookFormTextBox;