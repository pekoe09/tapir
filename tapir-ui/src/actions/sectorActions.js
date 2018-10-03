import sectorServices from '../services/sectorService'
import sectorService from '../services/sectorService';

export const SECTORS_GETALL_BEGIN = 'SECTORS_GETALL_BEGIN'
export const SECTORS_GETALL_SUCCESS = 'SECTORS_GETALL_SUCCESS'
export const SECTORS_GETALL_FAILURE = 'SECTORS_GETALL_FAILURE'

const getAllSectorsBegin = () => ({
  type: SECTORS_GETALL_BEGIN
})

const getAllSectorsSuccess = sectors => ({
  type: SECTORS_GETALL_SUCCESS,
  payload: { sectors }
})

const getAllSectorsFailure = error => ({
  type: SECTORS_GETALL_FAILURE,
  payload: { error }
})

export const getAllSectors = () => {
  return async (dispatch) => {
    dispatch(getAllSectorsBegin())
    try {
      const sectors = await sectorService.getAll()
      dispatch(getAllSectorsSuccess(sectors))
    } catch (error) {
      console.log(error)
      dispatch(getAllSectorsFailure(error))
    }
  }
}