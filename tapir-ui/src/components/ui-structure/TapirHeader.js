import React from 'react'
import styled from 'styled-components'

const StyledHeader = styled.div`
    padding: 15px;
  `

const StyledViewTitle = styled.div`
    font-size: 1.3em;
    margin: 0;
    display: inline;
  `

const TapirHeader = (props) => {
  return (
    <StyledHeader>
      <StyledViewTitle>
        {props.title}
      </StyledViewTitle>
      {props.children}
    </StyledHeader>
  )
}

export default TapirHeader