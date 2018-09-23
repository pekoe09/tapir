import React, { Component } from 'react';
import { Route, withRouter } from 'react-router-dom'
import { connect } from 'react-redux'
import App from 'grommet/components/App'
import TapirLayout from './components/ui-structure/TapirLayout'

class Main extends Component {
    render() {
        return (
            <App>
                <TapirLayout />
            </App>
        )
    }
}

export default withRouter(connect(
    null
)(Main))