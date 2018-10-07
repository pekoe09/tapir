import React from 'react'
import { ControlLabel, FormGroup, Col } from 'react-bootstrap'
import { StyledSubFormBordered, StyledFormControl, StyledSubForm, StyledCol } from '../ui-structure/StyledComponents'

const Address = ({ targetAddress, title, street1, street2, zip, city, country, handleAddressChange }) => {

  const emitChange = (e) => {
    const address = {
      street1: e.target.name === 'street1' ? e.target.value : street1,
      street2: e.target.name === 'street2' ? e.target.value : street2,
      zip: e.target.name === 'zip' ? e.target.value : zip,
      city: e.target.name === 'city' ? e.target.value : city,
      country: e.target.name === 'country' ? e.target.value : country
    }
    handleAddressChange(targetAddress, address)
  }

  return (
    <StyledSubFormBordered componentClass='fieldset'>
      <ControlLabel style={{ fontStyle: 'italic' }}>{title}</ControlLabel>
      <FormGroup>
        <ControlLabel>Street</ControlLabel>
        <StyledFormControl
          name='street1'
          type='text'
          value={street1}
          onChange={emitChange}
        />
      </FormGroup>
      <FormGroup>
        <ControlLabel>Street (cont.)</ControlLabel>
        <StyledFormControl
          name='street2'
          type='text'
          value={street2}
          onChange={emitChange}
        />
      </FormGroup>
      <StyledSubForm componentClass='fieldset' style={{ marginBottom: 0 }}>
        <StyledCol sm={4} style={{ paddingRight: 15 }}>
          <FormGroup>
            <ControlLabel>Zip</ControlLabel>
            <StyledFormControl
              name='zip'
              type='text'
              value={zip}
              onChange={emitChange}
            />
          </FormGroup>
        </StyledCol>
        <StyledCol sm={8}>
          <FormGroup>
            <ControlLabel>City</ControlLabel>
            <StyledFormControl
              name='city'
              type='text'
              value={city}
              onChange={emitChange}
            />
          </FormGroup>
        </StyledCol>
      </StyledSubForm>
      <FormGroup style={{ marginBottom: 0 }}>
        <ControlLabel>Country</ControlLabel>
        <StyledFormControl
          name='country'
          type='text'
          value={country}
          onChange={emitChange}
        />
      </FormGroup>
    </StyledSubFormBordered>
  )
}

export default Address