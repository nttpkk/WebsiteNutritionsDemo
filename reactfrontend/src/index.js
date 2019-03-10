import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import * as serviceWorker from './serviceWorker';
import ListUsersApp from './ListUsersApp';
import ListFoodsApp from './ListFoodsApp';
import OldApp123 from './OldApp123';

ReactDOM.render(
    <div>
    <ListUsersApp/>
    <OldApp123/>
    </div>
    , document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
