
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleUser } from '@fortawesome/free-regular-svg-icons';
import { faArrowUp, faArrowDown } from '@fortawesome/free-solid-svg-icons';
import { Comment } from '../models/comment';

interface Props {
    comment: Comment
}

function CommentComponent({comment}: Props) {
    return (
        <>
            <div className="pt-5">
                <p>{comment.text}</p>
                <footer className="flex flex-row justify-between">
                    <div className="flex flex-row justify-between">
                        <a href="like" className='px-1'>
                            <FontAwesomeIcon className='h-3' icon={faArrowUp} style={{ color: "#9ea4ae", }} />
                        </a>
                        <a href="dislike" className='px-1'>
                            <FontAwesomeIcon className='h-3' icon={faArrowDown} style={{ color: "#9ea4ae", }} />
                        </a>
                    </div>
                    <div className="flex flex-row justify-between">
                        <div className="flex flex-col justify-end">
                            <a className="flex justify-end" href="author">{comment.user.nickName}</a>
                            <a className="flex justify-end" href="entryDate">{comment.createdAt.slice(0, 10)}</a>
                        </div>
                        <div className="pt-2 pl-2">
                            <a href="icon" >
                                <FontAwesomeIcon className='h-10' icon={faCircleUser} style={{ color: "#9ea4ae", }} />
                            </a>
                        </div>
                    </div>
                </footer>
            </div>
        </>
    )
}

export default CommentComponent;