import styled from "styled-components";
import { loadingGif } from "../../assets/imageStore";

export default function LoadingComponent() {
    const Div = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    position:absolute;
    z-index: 10000;
    width:100%;
    height:100%;
    top: 0;
    background-color: white;
    `
    return (
        <Div>
            <img src={loadingGif}/>
        </Div>
    )

    
}