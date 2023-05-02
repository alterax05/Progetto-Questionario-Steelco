import {FC} from 'react';
import NavBar from "../components/NavBar";
import Video from "../components/YoutubeVideoEncoder";

interface VideoProps {
    isItalian: boolean;
    id?: string;
}

const VideoPage:FC<VideoProps> = ({isItalian}) => {
    return(
        <>
            <NavBar nomi_italiano={["Vai alle domande"]} nomi_inglese={["Go to questions"]} links={["/domande"]} isItalian={isItalian} setIsItalian={undefined}/>
            <Video/>
        </>
    )
}

export default VideoPage;