import styled from "styled-components"
import { splashGif } from "../../../assets/imageStore"


export default function SplashPage(){

    // const navigate = useNavigate();

    // useEffect(() => {
    //     setTimeout(()=> {
    //         alert()
    //     },3000)
    // },[])

    const Div = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    height: 100vh;
    `
    return (
        <Div>
            <img src={splashGif}/>
        </Div>
    )
}