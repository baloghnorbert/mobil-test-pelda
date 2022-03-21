import "./../styles/main.css";

import { IonItem, IonLabel, IonText, IonSelectOption, IonSelect } from "@ionic/react";
import React from "react";
import { Controller, FieldElement, Ref, RegisterOptions } from "react-hook-form";
import { IBaseProps } from "./../interfaces/BaseProps";
import { Position } from "./../../../client/client";

interface IHookFormSelectlistProps<T> extends IBaseProps
{
    label: string;
    value?: T | null;
    data: T[];
    placeholder?: string;
    displayMember: (item: T) => string;
    valueMember: (item: T) => string;
    onChange?: (item: T) => void;
    reference?<TFieldElement extends FieldElement<T>>(rules?: RegisterOptions): (ref: (TFieldElement & Ref) | null) => void;
}

function HookFormSelectList<T>(props: IHookFormSelectlistProps<T>): JSX.Element
{
  return (
  <React.Fragment>
      <IonItem>
          <IonLabel position="floating" class="label">{props.label}</IonLabel>
          <Controller name={props.name}
                      control={props.control}
                      defaultValue={props.value ? props.valueMember(props.value) : -1}
                      render={ ({field}) =>
                          <IonSelect aria-invalid={props.errors && props.errors[props.name] ? "true" : "false"}
                                     aria-describedby={`${props.name}Error`}
                                     placeholder={props.placeholder ? props.placeholder : "Válasszon ..."}
                                     onIonChange={(e) => field.onChange(e)}
                                     onIonBlur={(e) => field.onBlur()}
                                     value={field.value}
                                     disabled={props.disabled ? props.disabled : false}
                                     className="input-field" >
                            {
                              props.data.map((item: T) =>
                                <IonSelectOption key={props.valueMember(item)}
                                                 value={props.valueMember(item)}
                                                 class="ion-select">
                                  {props.displayMember(item)}
                                </IonSelectOption>
                              )
                            }
                          </IonSelect>
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

export function PositionSelectList(selectProps: IHookFormSelectlistProps<Position>): JSX.Element
{
    return HookFormSelectList<Position>(selectProps);
}