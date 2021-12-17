Load2('https://localhost:44324/apiArtEvents/getAllArtEvents');

class Hello extends React.Component {
    render() {
        return <h1>Привет, React.JS</h1>;
    }
}

class MainHeader extends React.Component {
    render() {
        return (<div>
            <div className="col-auto" style={{ height: "50px", backgroundColor: "greenyellow" }}> <p>Типа шапка</p></div >
            <MainTableWithEvents />
        </div>);
        
    }
}

class MainTableWithEvents extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,           
            items: []
        };
    }
    componentDidMount() {
        let url2 = 'https://localhost:44324/apiArtEvents/getAllArtEvents';
        Load(url2);
        fetch(url2)
            .then(res => res.json())
            .then(
                (result) => {
                    /*console.log("after Json",result),*/
                    this.setState({
                        isLoaded: true,
                        items: result
                    });
                }, 
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
        )        
    }

    render() {
        const { error, isLoaded, items } = this.state;        
        if (error) {
            return <div>Ошибка: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
            /*console.log("before return", items);*/
            let itemsInTable = items.map((item) => (

               <tr key={item.id}>
                    <td> {item.iventName}</td>
                    <td>{item.amounOfTicket}</td>
                    <td>{item.date}</td>
                    <td>{item.place}</td>
                    <td>{item.typeOfArtEvent}</td>
                    <td>{item.additionalInfo.map((info) => <p>{info }</p>)}</td>
                </tr>
                ));
            return (<div >
                <table width="100%" className="table table-bordered ">
                    <colgroup>
                        <col width="20%"></col>
                        <col width="10%"></col>
                        <col width="15%"></col>
                        <col width="17%"></col>
                        <col width="17%"></col>
                        <col width="21%"></col>
                    </colgroup>
                    <tbody>
                        {/*{console.log("inside tbody", items) }*/}
                        {itemsInTable }
                    </tbody>
                </table>
            </div>);
        }
    }
}

ReactDOM.render(
    <MainHeader />,
    document.getElementById("content")
);

function Load(url) {
    fetch(url)
        .then(function (responce) {
            responce.json().then(function (data) {
                console.log(data)
        })
    })
}

function Load2(url) {
    axios.get(url).then((result) => console.log(result));
}
