import axios from 'axios'

const baseUrl = '/api/businesssectors'

const getAll = async () => {
  const response = await axios.get(baseUrl)
  return response.data
}

export default {
  getAll
}