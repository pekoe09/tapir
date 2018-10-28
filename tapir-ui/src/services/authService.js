import axios from 'axios'

const baseUrl = '/api/account'

const register = async (user) => {
  const response = await axios.post(`${baseUrl}/register`, user)
  return response.data
}

const login = async (credentials) => {
  const response = await axios.post(`${baseUrl}/token`, credentials)
  return response.data
}

export default {
  login,
  register
}