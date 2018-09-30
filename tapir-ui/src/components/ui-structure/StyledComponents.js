import React from 'react'
import styled, { css } from 'styled-components'
import ReactTable from 'react-table'
import { Button, Modal, Form, FormControl } from 'react-bootstrap'
import { Link } from 'react-router-dom'

const StyledReactTable = styled(ReactTable)`
  margin: 10px;
`

const StyledModal = styled(Modal)`
  
`

const StyledForm = styled(Form)`
  margin: 15px;
  font-size: 0.8em;
`

const StyledFormControl = styled(FormControl)`
  font-size: 1.2em;
  height: fit-content;
`

const StyledLink = styled(Link)`
  color: white;
  text-decoration: none;
  display: inline;
  width: 100%;
  height: 100%;
  padding: 10px;
  padding-right: 50px;
  
  &:hover, &:focus, &:visited, &:link, &:active {
    text-decoration: none;
    color: white;
  }
`

const StyledButton = styled(Button)`
  color: white;
  background: blueviolet;
  border: none;
  text-shadow: none;
  box-shadow: none;
  display: inline;
  float: right;

  //${props => props.btntype === 'default' && css`
  //  background: darkgrey;
  //  color: black;
  //  &:hover, &:active {
  //    background: lightgrey;
  //    color: black;
  //  }
  //`}

  //${props => props.btntype === 'primary' && css`
  //    background: blueviolet;
  //    color: white;
  //    &:hover, &:active {
  //      background: indigo;
  //      color: white;
  //    }
  //  `}

  ${props => props.btntype === 'rowdanger' && css`
    background: white;
    color: indianred;
    border-style: solid;
    border-color: indianred;
    border-width: 1.5px;
    font-size: 0.8em;
    font-weight: 700;
    
    &:hover, &:focus {
      background: white;
      color: indianred;
      border-color: indianred;
      outline: none;
    }

    &:active:focus {
      background: pink;
      color: indianred;
      border-color: indianred;
      outline: none;
    }
  `}
`

const StyledLinkButton = ({ text, to, btntype }) => {
  return (
    <StyledLink to={to}>
      <StyledButton btntype={btntype}>{text}</StyledButton>
    </StyledLink>
  )
}

export {
  StyledReactTable,
  StyledButton,
  StyledForm,
  StyledFormControl,
  StyledLink,
  StyledLinkButton,
  StyledModal
}