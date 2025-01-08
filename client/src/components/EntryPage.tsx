import { useParams } from "react-router-dom";
import { Entry } from "../models/entry";
import CommentComponent from "./CommentComponent";
import { useEffect, useState } from "react";
import agent from "../api/agent";
import { Comment } from "../models/comment";
import CommentDialog from "./CommentDialog";


function EntryPage() {
    const { id } = useParams<{ id: string }>();
    const [title, setTitle] = useState<string>();
    const [comments, setComments] = useState<Comment[]>([]);
    const [isModalOpen, setModalOpen] = useState(false);

    useEffect(() => {
        if (id) {
            agent.Entries.details(parseInt(id))
                .then(entry => setTitle(entry.data.title))
                .catch(error => console.log(error))
            agent.Comments.list(parseInt(id))
                .then(r => setComments(r.data))
                .catch(error => console.log(error))
        }
    }, [id])

    return (
        <>
            <div className="py-5 w-[60%]">
                <div className="flex justify-between">
                    <div className="pb-4 font-bold text-2xl flex flex-row" >
                        {title}
                    </div>
                    <div >
                        <button onClick={() => setModalOpen(true)} className=" flex flex-row h6 bg-green-600 rounded-lg text-yellow-50 p-2">
                            add comment
                        </button>
                        <CommentDialog isModalOpen={isModalOpen} setIsModalOpen={setModalOpen} entryId={parseInt(id!)}/>
                    </div>
                </div>

                {comments.map(c => (
                    <CommentComponent comment={c} />
                ))}
            </div>
        </>
    )
}
export default EntryPage;