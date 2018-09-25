import React from 'react'
import { Link } from 'react-router-dom'
import styled from 'styled-components';

const StyledSidebarNav = styled.div`
  font-weight: 500;
  font-size: 1.3em;

  &:hover {
    background: indigo;
  }
`

const StyledLink = styled(Link)`
  color: white;
  text-decoration: none;
  display: inline-block;
  width: 100%;
  height: 100%;
  padding: 10px;
  padding-right: 50px;
  
  &:hover, &:focus, &:visited, &:link, &:active {
    text-decoration: none;
    color: white;
  }
`

const TapirSidebarNav = ({ text, linkTo }) => {
  return (
    <StyledSidebarNav>
      <StyledLink to={linkTo}>
        {text}
      </StyledLink>
    </StyledSidebarNav>
  )
}

export default TapirSidebarNav