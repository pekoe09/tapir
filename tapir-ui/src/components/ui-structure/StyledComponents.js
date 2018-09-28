import React from 'react'
import styled, { css } from 'styled-components'
import ReactTable from 'react-table'
import { Button } from 'react-bootstrap'
import { Link } from 'react-router-dom'

const StyledReactTable = styled(ReactTable)`
  margin: 10px;
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

  ${props => props.type == 'default' && css`
    background: darkgrey;
    color: black;
    &:hover, &:active {
      background: lightgrey;
      color: black;
    }
  `}

  ${props => props.type == 'primary' && css`
      background: blueviolet;
      color: white;
      &:hover, &:active {
        background: indigo;
        color: white;
      }
    `}
`

const StyledLinkButton = ({ text, to, type }) => {
  return (
    <StyledLink to={to}>
      <StyledButton type={type}>{text}</StyledButton>
    </StyledLink>
  )
}

export {
  StyledReactTable,
  StyledButton,
  StyledLink,
  StyledLinkButton
}