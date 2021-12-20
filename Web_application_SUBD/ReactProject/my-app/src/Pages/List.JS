import React,{Component} from 'react';
import { Table } from 'react-bootstrap';

export class List extends Component{

    constructor(props){
        super(props);
        this.state={list:[]}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API+'PersonalList')
        .then(response=>response.json())
        .then(data=>{
            this.setState({list:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }
    componentDidUpdate(){
        this.refreshList();
    }

    render(){
        const {list}=this.state;
        return(
            <div >
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>ProductId</tr>
                        <tr>ProductName</tr>
                        <tr>Options</tr>
                    </thead>
                    <tbody>
                        {list.map(l=>
                            <tr key={l.ProductId}>
                                <td>{l.ProductId}</td>
                                <td>{l.ProductName}</td>
                                <td>{l.ProductCount}</td>
                                <td>{l.ProductCost}</td>
                                <td>Increment / Delete</td>

                            </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
}