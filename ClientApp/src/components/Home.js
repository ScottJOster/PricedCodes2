import React, { Component, useState } from 'react';
import { FetchData } from './FetchData';

export function Home() {
    const [state, setState] = React.useState({

        postCodeStart: "M22",
        postCodeEnd: "9RS",
        isSubmitted: false,
        fullPostCode: ""
    })

    function handleChange(e) {

        const value = e.target.value;
        setState({
            ...state, [e.target.name]: value, isSubmitted: false
        });
        console.dir(state);
    }

    function handleSubmit(e) {

        e.preventDefault();

        var fullPostCode = state.postCodeStart.replace(/\s/g, '') + " " + state.postCodeEnd.replace(/\s/g, '');
        fullPostCode.replace(/\s/g, '');
        
        setState({
            ...state, isSubmitted: true, fullPostCode: fullPostCode
        });
        console.dir(state.fullPostCode);
        
       }


    if (!state.isSubmitted) {
     return (

        <div>
            <h1> Priced Codes </h1>
            <p> Please enter postcode below.... </p>
            <form onSubmit={handleSubmit}>
                <input placeholder={state.postCodeStart} maxLength={4} onChange={handleChange} type="text" name="postCodeStart" />
                <input placeholder={state.postCodeEnd} maxLength={4} onChange={handleChange} type="text" name="postCodeEnd" />
                <input type="submit" name="submit" />
            </form>
       </div>
    );
}

    return (<div>
        <h1> Priced Codes </h1>
        <p> Please enter postcode below.... </p>
        <form onSubmit={handleSubmit}>
            <input placeholder={state.postCodeStart} maxLength={4} onChange={handleChange} type="text" name="postCodeStart" />
            <input placeholder={state.postCodeEnd} maxLength={4} onChange={handleChange} type="text" name="postCodeEnd" />
            <input type="submit" name="submit" />
        </form>
        <FetchData fullPostCode={state.fullPostCode} />
           </div>) 
  
}
