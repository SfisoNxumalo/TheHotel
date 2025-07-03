import styled from "styled-components";
import { loadingGif } from "../../assets/imageStore";

export default function LoadingComponent() {
    const Div = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    `
    return (
        <Div>
            <img src={loadingGif}/>
        </Div>
    )

    
}