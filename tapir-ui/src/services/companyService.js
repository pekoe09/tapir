import axios from 'axios'

const baseUrl = '/api/companies'

const getAll = async () => {
  const response = await axios.get(baseUrl)
  return response.data
}

const addCompany = async (company) => {
  console.log('Posting company ', company)
  const response = await axios.post(baseUrl, company)
  return response.data
}

export default {
  getAll,
  addCompany
}