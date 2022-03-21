import "./../styles/main.css";

import { IonItem, IonLabel, IonTextarea, IonText } from "@ionic/react";
import React from "react";
import { Controller } from "react-hook-form";
import { IBaseProps } from "./../interfaces/BaseProps";

export interface IHookFormTextAreaProps extends IBaseProps
{
    label: string;
    value?: string | undefined;
    rows?: number;
    columns?: number;
    autoGrow?: boolean;
    debounce?: number;
}

const HookFormTextArea: React.FC<IHookFormTextAreaProps> = (props: IHookFormTextAreaProps): JSX.Element =>
{
    return (
    <React.Fragment>
        <IonItem>
            <IonLabel position="floating" class="label">{props.label}</IonLabel>
            <Controller name={props.name}
                        control={props.control}
                        defaultValue={props.value}
                        render={ ({field}) =>
                            <IonTextarea aria-invalid={props.errors && props.errors[props.name] ? "true" : "false"}
                                         aria-describedby={`${props.name}Error`}
                                         onIonChange={(e) => field.onChange(e)}
                                         onIonBlur={(e) => field.onBlur()}
                                         value={field.value}
                                         rows={props.rows ? props.rows : 5}
                                         cols={props.columns ? props.columns : 10}
                                         debounce={props.debounce ? props.debounce : 500}
                                         disabled={props.disabled ? props.disabled : false} 
                                         className="input-field" />
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

export default HookFormTextArea;