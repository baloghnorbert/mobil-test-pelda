import { yupResolver } from "@hookform/resolvers/yup";
import { IonButton, IonCol, IonContent, IonFooter, IonGrid, IonHeader, IonItem, IonPage, IonRow, NavContext } from "@ionic/react";
import React, { useState, useEffect, useContext, useCallback } from "react";
import { useForm } from "react-hook-form";
import { WebAPI } from "./../../service/webAPI";
import { LoginRequest, TokenResponse } from "./../../client/client";
import { validationSchema } from "./validation";
import HookFormTextBox from "../../library/hooksFormControlls/components/hookFomTextBox";

const LoginPage:React.FC = (): JSX.Element =>
{
    const {control, handleSubmit, formState: {errors}, formState} = useForm<LoginRequest>
    ({
        mode: "onChange",
        resolver: yupResolver(validationSchema)
    });

    const { navigate } = useContext(NavContext);
    const redirectToHomePage = useCallback(() => navigate("/home", "forward"), [navigate]);
    const redirectToRegisterPage = useCallback(() => navigate("/register", "forward"), [navigate]);

    const onSubmit = async (data: LoginRequest): Promise<void> =>
    {
        const response: TokenResponse = await WebAPI.Security.login(data)

        if(response && response.token)
        {
            WebAPI.setToken(response.token)
            redirectToHomePage();
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
                <form onSubmit={handleSubmit((data: LoginRequest) => onSubmit(data))}>
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
                                LOGIN
                            </IonButton>
                        </IonCol>
                    </IonRow>            
                </form>
            </IonGrid>
        </IonContent>
        <IonFooter>
            <IonButton expand="block" onClick={() => redirectToRegisterPage()}>Register</IonButton>
        </IonFooter>
    </IonPage>
    );
}

export default LoginPage;