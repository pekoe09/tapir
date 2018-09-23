﻿import { createStore, combineReducers, applyMiddleware } from 'redux'
import thunk from 'redux-thunk'
import { persistStore, persistReducer } from 'redux-persist'
import storage from 'redux-persist/lib/storage'
import autoMergeLevel2 from 'redux-persist/lib/stateReconciler/autoMergeLevel2'

const appReducer = combineReducers({

})

export const rootReducer = (state, action) => {
    if (action.type === 'LOGOUT_SUCCESS') {
        Object.keys(state).forEach(key => {
            storage.removeItem(`persist:${key}`)
        })
        state = undefined
    }
}

export const persistConfig = {
    key: 'tapir',
    storage,
    stateReconciler: autoMergeLevel2
}

const persistedReducer = persistReducer(persistConfig, rootReducer)

export const store = createStore(
    persistedReducer,
    applyMiddleware(thunk)
)

export const persistor = persistStore(store)