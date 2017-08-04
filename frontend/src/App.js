import React, { Component } from 'react';
import logo from './logo.svg';
import axios from 'axios';
import './App.css';
import './speech.css'

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {response: '', value: ''};
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.getUppercase = this.getUppercase.bind(this);
  }
  getUppercase(input) {
    var quoted = '"' + input + '"';
    axios.post('https://txsca3462b.execute-api.us-west-2.amazonaws.com/deployed/mydemoresource', quoted)
      .then(response => {
        console.log(response);
        this.setState({'response': response.data});
      })
      .catch(exception => {
        console.log('Connection error');
      });
  }
  handleChange(event) {
    this.setState({value: event.target.value});
  }
  handleSubmit(event) {
    event.preventDefault();
    this.getUppercase(this.state.value);
  }
  render() {
    const re = this.state.response == '' ? null : 
          <p className="triangle-right">
            {this.state.response}
          </p>
    return (
      <div className="App">
        <div className="Speech box">
          {re}
        </div>
        <div>
            <img src="http://i.imgur.com/gvytsS3.jpg" alt="flying pig" />
        </div>
          <form onSubmit={this.handleSubmit}>
            <label>
              Input string
              </label>
              <br/>
            <input type="text" value={this.state.value} onChange={this.handleChange} />
            <input type="submit" value="Submit" />
          </form>
      </div>
    );
  }
}

export default App;
