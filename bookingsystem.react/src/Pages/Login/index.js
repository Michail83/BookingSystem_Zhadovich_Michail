import React from 'react';
// import React, { Component } from 'react'
import ExternalLoginList from "../../components/ExternalLogin/ExternalLoginList"

function LoginPage() {
  console.log("CURRENT PAGE IS ========= "+window.location.href);
return (
<ExternalLoginList/>
)}




// class LoginPage extends React.Component {
//     componentDidMount() {
      
//       const _onInit = auth2 => {
//         console.log('init OK', auth2)
//       }

//       const _onError = err => {
//         console.log('error', err)
//       }

//       window.gapi.load('auth2', function() {
//         window.gapi.auth2
//           .init({               
//             //    разобраться с .env и перенести
//             client_id:"888637803632-1f5fpip1a2dpfimfdj0nfaojeb20m4rd.apps.googleusercontent.com",
//           })
//           .then(_onInit, _onError)
//       })
//     }
//     check = ()=>{
        
//     }

//     signIn = () => {
//       const auth2 = window.gapi.auth2.getAuthInstance()
//       auth2.signIn().then(googleUser => {      
        
//         const profile = googleUser.getBasicProfile()
//         console.log('ID: ' + profile.getId()) // не посылайте подобную информацию напрямую, на ваш сервер!
//         console.log('Full Name: ' + profile.getName())
//         console.log('Given Name: ' + profile.getGivenName())
//         console.log('Family Name: ' + profile.getFamilyName())
//         console.log('Image URL: ' + profile.getImageUrl())
//         console.log('Email: ' + profile.getEmail())
  
//         // токен
//         const id_token = googleUser.getAuthResponse().id_token
//         console.log('ID Token: ' + id_token)
//       })
//     }

//     signOut = () => {
//       const auth2 = window.gapi.auth2.getAuthInstance()
//       auth2.signOut().then(function() {
//         console.log('User signed out.')
//       })
//     }

//     render() {
//       return (
//         <div className="App">
//           <header className="App-header">
//             <button onClick={this.signIn}>Log in</button>
//             <button onClick={this.signOut}>Log out</button>
//             <button onClick={this.signOut}> check API</button>
//           </header>
//         </div>
//       )
//     }
//   }

export default LoginPage;