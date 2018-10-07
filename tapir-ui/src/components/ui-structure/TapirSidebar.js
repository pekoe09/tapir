import React from 'react'
import styled from 'styled-components'
import TapirSidebarNav from './TapirSidebarNav'

const StyledSidebar = styled.div`
  height: 100vh;
  position: sticky;
  z-index: 1;
  top: 0;
  left: 0;
  overflow-x: 'hidden';
  transition: 0.5s;
  font-family: 'Open Sans';
  background: blueviolet;
  color: white;
`

const TapirSidebar = () => {
  return (
    <StyledSidebar>
      <h3 style={{ fontweight: 800 }}>
        Tapiiri
      </h3>
      <TapirSidebarNav
        text='Companies'
        linkTo='/companies'
      />
      <TapirSidebarNav
        text='Persons'
        linkTo='/persons'
      />
      <TapirSidebarNav
        text='Employments'
        linkTo='/employments'
      />
    </StyledSidebar>
  )
}

export default TapirSidebar