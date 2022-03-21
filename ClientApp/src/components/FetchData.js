import React, { Component } from 'react';
import { PropertyMap } from './PropertyMap'

export class FetchData extends Component {
   
 constructor(props) {
        super(props);
        this.state = { properties: [], loading: true };
    }

    componentDidMount() {
        this.populatePropertyData();
    }

    static renderPropertiesTable(properties) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr> 
                        <th>PostCode</th>
                        <th>SoldPrice </th>
                        <th>PropertyType</th>
                    </tr>
                </thead>
                <tbody>
                    { properties?.map(property =>
                        <tr key={property.iD}>
                            <td>{property.postCode}</td>
                            <td>{property.soldPrice}</td>
                            <td>{property.propertyType}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderPropertiesTable(this.state.properties);

        return (
            <div>
                <h1 id="tabelLabel" >Sold Properties </h1>
               
                {contents}
                <PropertyMap properties={this.state.properties} />
            </div>
        );
    }

  async populatePropertyData() {

        const pRes = await fetch(`property/GetAllLocalSoldPricesForPostCode?postcode=${this.props.fullPostCode}`);
        const { data } = await pRes.json();
        this.setState({ properties: data, loading: false });
        return (<PropertyMap properties={this.state.properties} />)
        }
}


