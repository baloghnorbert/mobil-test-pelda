import "./../Styles/main.css"

import { IonItem, IonLabel, IonText, IonCheckbox } from "@ionic/react";
import React, { useEffect } from "react";
import { Controller } from "react-hook-form";
import { IBaseProps } from "../interfaces/BaseProps";

export interface IHookFormCheckboxProps extends IBaseProps
{
    label: string;
    checked?: boolean | undefined;
    slot?: "start" | "end";
    onChange?: (e: boolean) => void;
}

const HookFormCheckbox: React.FC<IHookFormCheckboxProps> = (props: IHookFormCheckboxProps): JSX.Element =>
{

    return (
    <React.Fragment>
        <IonItem lines="none">
            <IonLabel position="floating" class="label" style={ {margin: "-5px 0px 35px 0px"} }>
                {props.label}
            </IonLabel>
            <Controller name={props.name}
                        control={props.control}
                        defaultValue={props.defaultValue}
                        render={ ({field}) =>
                            <IonCheckbox aria-invalid={props.errors && props.errors[props.name] ? "true" : "false"}
                                         aria-describedby={`${props.name}Error`}
                                         slot={props.slot ? props.slot : "start"}
                                         onIonChange={(e) => field.onChange(e)}
                                         onIonBlur={(e) => field.onBlur()}
                                         value={field.value}
                                         disabled={props.disabled ? props.disabled : false} />
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

export default HookFormCheckbox;