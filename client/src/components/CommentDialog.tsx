import { useState } from "react";
import agent from "../api/agent";
import { useNavigate } from "react-router-dom";

interface Props {
    isModalOpen: boolean,
    setIsModalOpen: (state: boolean) => void,
    entryId: number
}
function CommentDialog({ isModalOpen, setIsModalOpen, entryId}: Props) {
    const [message, setMessage] = useState<string>("");
    const navigate = useNavigate();
    const clickHandler = () => {
        agent.Comments.add(entryId, {text: message})// anonim model yarattık "text": "mesajim burda"
        .then(() => {
            setIsModalOpen(!isModalOpen)
            navigate(0)
        })
        .catch(e => console.log(e))
    }
    const onChangeHandler = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
        setMessage(e.target.value)
    }

    return (
        <>
            <dialog open={isModalOpen} id="modal" className="backdrop:bg-gray-700 bg-gray-50 w-4/6 h-3/6">
                <form method="dialog" className="text-center">
                    <textarea className="m-2 w-11/12 h-80" onChange={onChangeHandler} />
                </form>
                <button onClick={clickHandler} className="p-0.5 ">Gonder Gitsin</button>
            </dialog>
        </>
    )
}

export default CommentDialog;