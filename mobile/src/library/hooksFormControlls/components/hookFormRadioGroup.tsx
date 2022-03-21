import "./../styles/main.css"

import { IonItem, IonLabel, IonText, IonRadioGroup, IonRadio } from "@ionic/react";
import React from "react";
import { Controller } from "react-hook-form";
import { IBaseProps } from "../interfaces/BaseProps";
import { InputValueType } from "./../types/InputValueType";

export interface IHookFormRadioGroupProps extends IBaseProps
{
    label: string;
    value?: InputValueType;
    options: string[];
    allowEmptySelection?: boolean;
}

const HookFormRadioGroup: React.FC<IHookFormRadioGroupProps> = (props: IHookFormRadioGroupProps): JSX.Element =>
{
    return (
    <React.Fragment>
        <IonItem disabled={props.disabled ? props.disabled : false}>
            <IonLabel position="floating" class="label">{props.label}</IonLabel>
            <Controller name={props.name}
                        control={props.control}
                        defaultValue={props.defaultValue}
                        render={ ({field}) =>
                            <IonRadioGroup aria-invalid={props.errors && props.errors[props.name] ? "true" : "false"}
                                           aria-describedby={`${props.name}Error`}
                                           allowEmptySelection={props.allowEmptySelection ? props.allowEmptySelection : true}
                                           onIonChange={(e) => field.onChange(e)}
                                           onBlur={(e) => field.onBlur()}
                                           value={field.value}>
                                {
                                    props.options.length > 0 && props.options.map((option: string, i: number) =>
                                    (
                                        <IonItem lines="none" key={`${i}-${option}`}>
                                            <IonRadio value={option} slot="start"/>
                                            <IonLabel>{option}</IonLabel>
                                        </IonItem>
                                    ))
                                }
                            </IonRadioGroup>
                        }
            />
        </IonItem>
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
    </React.Fragment>
    );
}

export default HookFormRadioGroup;