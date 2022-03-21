import { yupResolver } from "@hookform/resolvers/yup";
import { IonButton, IonCol, IonContent, IonFooter, IonGrid, IonHeader, IonItem, IonLabel, IonPage, IonRow, NavContext } from "@ionic/react";
import React, { useState, useEffect, useContext, useCallback } from "react";
import { useForm } from "react-hook-form";
import { WebAPI } from "./../../service/webAPI";
import { RegisterRequest, TokenResponse } from "./../../client/client";
import { validationSchema } from "./validation";
import HookFormTextBox from "../../library/hooksFormControlls/components/hookFomTextBox";

const RegisterPage:React.FC = (): JSX.Element =>
{
    const {control, handleSubmit, formState: {errors}, formState} = useForm<RegisterRequest>
    ({
        mode: "onChange",
        resolver: yupResolver(validationSchema)
    });

    const { navigate } = useContext(NavContext);
    const redirectToHomePage = useCallback(() => navigate("/home", "forward"), [navigate]);
    const redirectToLoginPage = useCallback(() => navigate("/login", "forward"), [navigate]);

    const onSubmit = async (data: RegisterRequest): Promise<void> =>
    {
        const response: boolean = await WebAPI.Security.register(data)

        if(response)
        {
            redirectToLoginPage();
        }
    }

    return (
    <IonPage>
        <IonHeader className="flex center">
            <IonItem lines="none">Amazons of Volleyball</IonItem>
        </IonHeader>
        <IonContent fullscreen>
            <IonGrid className="flex center-vertical">
                <div className="flex center"><img src="./assets/images/logo.png" alt="logo" className="logo"/></div>
                <form onSubmit={handleSubmit((data: RegisterRequest) => onSubmit(data))}>
                    <IonRow>
                        <IonCol sizeXs="12">
                            <HookFormTextBox name="name"
                                            label="Name"
                                            type="text"
                                            control={control} 
                                            errors={errors} />
                        </IonCol>
                    </IonRow>
                    <IonRow>
                        <IonCol sizeXs="12">
                            <HookFormTextBox name="username"
                                            label="Username"
                                            type="text"
                                            control={control} 
                                            errors={errors} />
                        </IonCol>
                    </IonRow>
                    <IonRow>
                        <IonCol sizeXs="12">
                            <HookFormTextBox name="password"
                                            label="Password"
                                            type="password"
                                            control={control} 
                                            errors={errors} />
                        </IonCol>
                    </IonRow>
                    <IonRow className="flex center">
                        <IonCol>
                            <IonButton expand="block" type="submit" className="ion-margin-top"
                                       disabled={!formState.isValid}>
                                REGISTER
                            </IonButton>
                        </IonCol>
                    </IonRow>           
                </form>
            </IonGrid>
        </IonContent>
        <IonFooter>
            <IonButton expand="block" onClick={() => redirectToLoginPage()}>Login</IonButton>
        </IonFooter>
    </IonPage>
    );
}

export default RegisterPage;