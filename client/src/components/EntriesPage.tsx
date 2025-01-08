import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleUser } from '@fortawesome/free-regular-svg-icons';
import { faArrowUp, faArrowDown } from '@fortawesome/free-solid-svg-icons';
import { useEffect, useState } from 'react';
import { Entry } from '../models/entry';
import agent from '../api/agent';
import { Link } from 'react-router-dom';


function EntriesPage() {
    const [entries, setEntries] = useState<Entry[]>([]);

    const fetchEntries = async () => {
        const response = await agent.Entries.list()
        //  console.log(response.data);
        return response;
    }

    useEffect(() => {
        fetchEntries()
            .then(({ data }) => setEntries(data))
        // console.log(entries[1]);
    }, [])

    return (
        <>
            <div className='w-[50%]'>
                {entries.map((entry) => (
                    <div key={entry.id} className="pt-5">
                        <Link to={`entry/${entry.id}`}>
                        <h1 className="pb-4 font-bold text-2xl">{entry.title}</h1>
                        </Link>
                        <p>{entry.description}</p>
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
                                    <a className="flex justify-end" href="author">{entry.nickname}</a>
                                    <a className="flex justify-end" href="entryDate">{entry.createdAt.slice(0, 10)}</a>
                                </div>
                                <div className="pt-2 pl-2">
                                    <a href="icon" >
                                        <FontAwesomeIcon className='h-10' icon={faCircleUser} style={{ color: "#9ea4ae", }} />
                                    </a>
                                </div>
                            </div>
                        </footer>
                    </div>
                )

                )}
            </div>


            {/* <div className="flex-1 bg-red-400 p-4">
                <h1 className="pb-4 font-bold text-2xl">ilk kez yemege cikacaklara tavsiyeler</h1>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ea libero unde eligendi, quo perspiciatis nemo autem provident nam quas tempore corporis.Quo, laborum tempora.</p>
                <footer className="flex flex-row justify-between">
                    <div className="flex flex-row justify-between">
                        <a href="like">like</a>
                        <a href="dislike">dislike</a>
                    </div>
                    <div className="flex flex-row justify-between">
                        <div className="flex flex-col justify-end">
                            <a className="flex justify-end" href="author">author</a>
                            <a className="flex justify-end" href="entryDate">entryDate</a>
                        </div>
                        <div className="pt-2 pl-2">
                            <a href="icon" >
                                <FontAwesomeIcon className='h-10' icon={faCircleUser} style={{ color: "#9ea4ae", }} />

                            </a>
                        </div>
                    </div>
                </footer>

            </div> */}
        </>
    )
}

export default EntriesPage;