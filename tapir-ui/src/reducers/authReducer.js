import {
  REGISTER_USER_BEGIN,
  REGISTER_USER_SUCCESS,
  REGISTER_USER_FAILURE,
  LOGIN_BEGIN,
  LOGIN_SUCCESS,
  LOGIN_FAILURE,
  LOGOUT_BEGIN,
  LOGOUT_SUCCESS,
  LOGOUT_FAILURE
} from '../actions/authActions'

const initialState = {
  currentUser: null,
  registering: false,
  loggingIn: false,
  loggingOut: false,
  error: null
}

const authReducer = (store = initialState, action) => {
  switch (action.type) {
    case REGISTER_USER_BEGIN:
      return {
        ...store,
        registering: true,
        error: null
      }
    case REGISTER_USER_SUCCESS:
      return {
        ...store,
        currentUser: action.payload.newUser,
        registering: false,
        error: null
      }
    case REGISTER_USER_FAILURE:
      return {
        ...store,
        registering: false,
        error: action.payload.error
      }
    case LOGIN_BEGIN:
      return {
        ...store,
        loggingIn: true,
        loggingOut: false,
        error: null
      }
    case LOGIN_SUCCESS:
      return {
        ...store,
        currentUser: action.payload.currentUser,
        loggingIn: false,
        loggingOut: false,
        error: false
      }
    case LOGIN_FAILURE:
      return {
        ...store,
        currentUser: null,
        loggingIn: false,
        loggingOut: false,
        error: action.payload.error
      }
    case LOGOUT_BEGIN:
      return {
        ...store,
        loggingOut: true,
        loggingIn: false,
        error: null
      }
    case LOGOUT_SUCCESS:
      return {
        ...store,
        currentUser: null,
        loggingOut: false,
        loggingIn: false,
        error: null
      }
    case LOGOUT_FAILURE:
      return {
        ...store,
        loggingOut: false,
        loggingIn: false,
        error: action.payload.error
      }
    default:
      return store
  }
}

export default authReducer