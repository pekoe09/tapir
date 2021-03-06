﻿import {
  COMPANIES_GETALL_BEGIN,
  COMPANIES_GETALL_SUCCESS,
  COMPANIES_GETALL_FAILURE,
  COMPANY_CREATE_BEGIN,
  COMPANY_CREATE_SUCCESS,
  COMPANY_CREATE_FAILURE,
  COMPANY_UPDATE_BEGIN,
  COMPANY_UPDATE_SUCCESS,
  COMPANY_UDPATE_FAILURE,
  COMPANY_DELETE_BEGIN,
  COMPANY_DELETE_SUCCESS,
  COMPANY_DELETE_FAILURE
} from '../actions/companyActions'

const initialState = {
  items: [],
  loading: false,
  creating: false,
  updating: false,
  deleting: false,
  error: null
}

const companyReducer = (store = initialState, action) => {
  switch (action.type) {
    case COMPANIES_GETALL_BEGIN:
      return {
        ...store,
        loading: true,
        error: null
      }
    case COMPANIES_GETALL_SUCCESS:
      return {
        ...store,
        items: action.payload.companies,
        loading: false,
        error: null
      }
    case COMPANIES_GETALL_FAILURE:
      return {
        ...store,
        loading: false,
        error: action.payload.error
      }
    case COMPANY_CREATE_BEGIN:
      return {
        ...store,
        creating: true,
        error: null
      }
    case COMPANY_CREATE_SUCCESS:
      return {
        ...store,
        items: store.items.concat(action.payload.company),
        creating: false,
        error: null
      }
    case COMPANY_CREATE_FAILURE:
      return {
        ...store,
        creating: false,
        error: action.payload.error
      }
    case COMPANY_UPDATE_BEGIN:
      return {
        ...store,
        updating: true,
        error: null
      }
    case COMPANY_UPDATE_SUCCESS:
      const updated = action.payload.company
      return {
        ...store,
        items: store.items.map(c => c.id === updated.id ? updated : c),
        updating: false,
        error: null
      }
    case COMPANY_UDPATE_FAILURE:
      return {
        ...store,
        updating: false,
        error: action.payload.error
      }
    case COMPANY_DELETE_BEGIN:
      return {
        ...store,
        deleting: true,
        error: null
      }
    case COMPANY_DELETE_SUCCESS:
      return {
        ...store,
        items: store.items.filter(c => c.id !== action.payload.company.id),
        deleting: false,
        error: null
      }
    case COMPANY_DELETE_FAILURE:
      return {
        ...store,
        deleting: false,
        error: action.payload.error
      }
    default:
      return store
  }
}

export default companyReducer