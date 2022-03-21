import "./../styles/main.css"

import { IonItem, IonLabel, IonText, IonDatetime } from "@ionic/react";
import React from "react";
import { Controller } from "react-hook-form";
import { IBaseProps } from "../interfaces/BaseProps";

export interface IHookFormDateTimePickerProps extends IBaseProps
{
    label: string;
    value?: Date | string;
    displayFormat?: string;
    startDate?: Date | string;
    endDate?: Date | string;
}

const HookFormDateTimePicker: React.FC<IHookFormDateTimePickerProps> = (props: IHookFormDateTimePickerProps): JSX.Element =>
{
    const formatDate = (date: Date | any): string =>
    {
      if (!(date instanceof Date))
      {
        date = new Date(date);
      }

      const day: string = pad(date.getDate(), 2);
      const month: string = pad(date.getMonth() + 1, 2);
      const year: string = pad(date.getFullYear(), 4);
      return `${year}-${month}-${day}`;
    }

    const pad = (num: number, size: number): string =>
    {
        const s = "000000000" + num;
        return s.substr(s.length - size);
    }

    const addDays = (date: Date, days: number): Date =>
    {
        date.setDate(date.getDate() + days);
        return date;
    }

    return (
    <React.Fragment>
        <IonItem>
            <IonLabel position="floating" class="label">{props.label}</IonLabel>
            <Controller name={props.name}
                        control={props.control}
                        defaultValue={props.defaultValue}
                        render={ ({field}) =>
                            <IonDatetime aria-invalid={props.errors && props.errors[props.name] ? "true" : "false"}
                                         aria-describedby={`${props.name}Error`}
                                         displayFormat={props.displayFormat ? props.displayFormat : "YYYY-MM-DD"}
                                         onIonChange={(e) => field.onChange(e)}
                                         onIonBlur={(e) => field.onBlur()}
                                         value={field.value instanceof Date ? field.value.toLocaleString() : formatDate(field.value)}
                                         min={
                                                props.startDate ?
                                                    props.startDate instanceof Date ?
                                                        formatDate(props.startDate) :
                                                        formatDate(new Date(props.startDate)) :
                                                    formatDate(new Date(0,0,0,0,0,0,0))
                                         }
                                         max={
                                                 props.endDate ?
                                                 props.endDate instanceof Date ?
                                                     formatDate(props.endDate) :
                                                     formatDate(new Date(props.endDate)) :
                                                 formatDate(new Date())
                                         }
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

export default HookFormDateTimePicker;