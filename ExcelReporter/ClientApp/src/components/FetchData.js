import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = {
      forecasts: [],
      loading: true,
      uploadedFile: null,
    };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
      <div>
        <form>
          <div>
            <label>Select file to upload</label>
              <input type="file" onChange={(e) => this.setState({ uploadedFile: e.currentTarget.files[0] })} />
          </div>
          <button onClick={this.handleFileUpload}>Upload!</button>
        </form>
      </div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  handleFileUpload = async e => {
    e.preventDefault();

    const userName = 'testUser';

    const formData = new FormData();
    formData.append("sentFile", this.state.uploadedFile);

    const token = await authService.getAccessToken();
    if (this.state.uploadedFile) {
      fetch(`api/ReportStatements/${userName}`, {
        method: 'post',
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` },
        body: formData
      })
      .then(res => res.json())
      .then(res => {
        console.log(res);
      })
    }
    else return;
  }

  async populateWeatherData() {
    const token = await authService.getAccessToken();
    const response = await fetch('weatherforecast', {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const data = await response.json();
      this.setState({ forecasts: data, loading: false });

    //POST request with location string as body
    //const reqBody = 'D:/file.xlsx';
    //fetch('api/ReportStatements/testUser', {
    //  method: 'post',
    //  headers: !token ? {} : { 'Authorization': `Bearer ${token}`, 'Content-Type': 'application/json' },
    //  body: JSON.stringify(reqBody)
    //}).then(res => res.json())
    //  .then(res => {
    //    console.log(res);
    //  })

    // GET request -> receive generated file
    // const userName = 'testUser';
    // fetch(`api/ReportStatements/${userName}/GetFile`, {
    //   headers: !token ? {} : { 'Authorization': `Bearer ${token}`, 'Content-Type': 'application/json' },
    // }).then(response => response.blob())
    //   .then(blob => {
    //   const url = window.URL.createObjectURL(blob);
    //   let a = document.createElement('a');
    //   a.href = url;
    //   a.download = userName + '.xlsx';
    //   document.body.appendChild(a); // we need to append the element to the dom -> otherwise it will not work in firefox
    //   a.click();
    //   a.remove();
    // })
  }
}
