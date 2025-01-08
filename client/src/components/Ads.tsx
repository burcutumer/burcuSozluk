import { useEffect, useState } from "react";
import { Tag } from "../models/tag";
import agent from "../api/agent";

function Ads() {
    return (
        <>
            <div className="w-[25%] pt-6 pl-6 mr-8 max-h-screen overflow-y-auto">
                <div className="pr-4">
                    <section className="flex">
                        <h3>gundem</h3>
                        <button className="pl-3" type="button">*</button>
                    </section>
                    <section>
                        <ul>
                            ich erstelle eine schone nutzliche Website
                        </ul>

                    </section>
                </div>
            </div>

        </>
    )

}

export default Ads;