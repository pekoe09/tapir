import React from 'react'
import ReactDOM from 'react-dom'
import Main from './Main'
import { BrowserRouter as Router } from 'react-router-dom'
import { Provider } from 'react-redux'
import { PersistGate } from 'redux-persist/integration/react'
import { store, persistor } from './store'

const render = () => {
    ReactDOM.render(
        <Provider store={store}>
            <PersistGate loading={null} persistor={persistor}>
                <Router>
                    <Main />
                </Router>
            </PersistGate>
        </Provider>,
        document.getElementById('root')
    )
}

render()
store.subscribe(render)