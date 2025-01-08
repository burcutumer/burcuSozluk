import { useEffect, useState } from "react";
import { Tag } from "../models/tag";
import agent from "../api/agent";

function Sidebar() {

    const [tags, setTags] = useState<Tag[]>([]);

    const fetchTags = async () => {
        const response = await agent.Tags.list();
        return response;
    }

    useEffect(() => {
        fetchTags()
            .then(({ data }) => setTags(data))
    }, [])

    return (
        <>
            <div className="w-[25%] pt-6 pl-20 max-h-screen overflow-y-auto">
                <div className="pr-10">
                    <section className="flex">
                        <h3>gundem</h3>
                        <button className="pl-3" type="button">*</button>
                    </section>
                    <section>
                        <ul>
                            {tags.map((tag) => (
                                <li key={tag.id} className="py-2">
                                    <a href="#" className="flex justify-between">
                                        <span>{tag.name}</span>
                                        <span>{tag.id}</span>
                                    </a>
                                </li>
                            )
                            )}
                        </ul>

                    </section>
                </div>
            </div>

        </>
    )

}

export default Sidebar;