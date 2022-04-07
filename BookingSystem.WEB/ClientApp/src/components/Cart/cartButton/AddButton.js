import React from "react"
import { connect } from "react-redux";


import actionCreator from "../../../Store/ActionsCreators/actionCreator";



const AddButton =({id, active, submitHandler})=>{
    // let input;

    return (
        <form>
            {/* <input type= "number" min='0' max='100' defaultValue={1}  ref={node => input = node}/> */}                                                    
            <button disabled={active} onClick={()=>{submitHandler(id)}} type="button">ADD</button>
        </form>
    )
}

const mapStateToProps=(state, ownProps)=> ({
    active: state.cartMap.has(ownProps.id)
 }); 
const mapDispatchToProps=dispatch=> (
{        
    submitHandler: (id) => dispatch(actionCreator.addToCart(id)),    
});

var AddButton_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(AddButton);

export default AddButton_ReduxWrapped;