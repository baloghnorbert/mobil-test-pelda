import React from 'react';
import { Redirect, Route } from 'react-router-dom';
import ProtectedRoute from './library/protectedRoute';
import { IonApp, IonRouterOutlet } from '@ionic/react';
import { IonReactRouter } from '@ionic/react-router';
import HomePage from './pages/home/Home';
import ProfilePage from './pages/profile/profile.page';
import CreatePage from './pages/create/crate.page';
import UpdatePage from './pages/update/update.page';
import LoginPage from './pages/login/login.page';
import RegisterPage from './pages/register/register.page';

/* Core CSS required for Ionic components to work properly */
import '@ionic/react/css/core.css';

/* Basic CSS for apps built with Ionic */
import '@ionic/react/css/normalize.css';
import '@ionic/react/css/structure.css';
import '@ionic/react/css/typography.css';

/* Optional CSS utils that can be commented out */
import '@ionic/react/css/padding.css';
import '@ionic/react/css/float-elements.css';
import '@ionic/react/css/text-alignment.css';
import '@ionic/react/css/text-transformation.css';
import '@ionic/react/css/flex-utils.css';
import '@ionic/react/css/display.css';

/* Theme variables */
import './theme/variables.css';
import './theme/global.css';

/* React Loader css */
import "react-loader-spinner/dist/loader/css/react-spinner-loader.css"


const App: React.FC = () => (
  <IonApp>
    <IonReactRouter>
      <IonRouterOutlet>
        <Route exact={true} path="/login">
          <LoginPage />
        </Route>
        <Route exact={true} path="/register">
          <RegisterPage />
        </Route>
        <ProtectedRoute exact={true} path="/home" component={HomePage} />
        <ProtectedRoute exact={true} path="/create" component={CreatePage} />
        <ProtectedRoute exact={true} path="/update/:id" component={UpdatePage} />
        <ProtectedRoute exact={true} path="/profile/:id" component={ProfilePage} />
        <Route exact={true} path="/">
          <Redirect to="/home" /> 
        </Route>
      </IonRouterOutlet>
    </IonReactRouter>
  </IonApp>
);

export default App;
