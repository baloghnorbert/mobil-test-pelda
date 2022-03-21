import { NavContext } from "@ionic/react";
import React, { Component, useCallback, useContext } from "react";
import { Redirect, Route } from "react-router-dom";
import { WebAPI } from "./../service/webAPI";
import { StorageService } from "../storage/storage.service";

interface ProtectedRouteProps
{
  component: React.ComponentType<any>;
  path: string;
  exact: boolean;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = (props: ProtectedRouteProps): JSX.Element =>
{
    const token: string | null = WebAPI.getToken();

    const isAuthenticated = token ? true : false;

    return isAuthenticated ?
           <Route path={props.path} exact={props.exact} render={() => <props.component />} /> :
           <Redirect to="/login" />
}

export default ProtectedRoute;