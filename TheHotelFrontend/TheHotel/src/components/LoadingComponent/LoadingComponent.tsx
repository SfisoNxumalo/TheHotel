import styled from "styled-components";
import { loadingGif } from "../../assets/imageStore";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

interface LoadingComponentProps{
    message:string
}
export default function LoadingComponent({message}:LoadingComponentProps) {
    const navigate = useNavigate();
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
    bottom:0;
    background-color: white;
    `
    return (
        <Div>
            <img src={loadingGif}/>
            <p>{message}</p>
            <Button onClick={() => {navigate('/auth/login')}}>Exit</Button>
        </Div>
    )

    
}