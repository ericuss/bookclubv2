import moment from 'moment'
import { FC } from "react";
import { useVoteList } from "./useVoteList.hook";
import './index.css';
import { Card } from "react-bootstrap";
import { VoteList } from "@/app/shared/types/types";
import './index.scss';

const selfWindow: Window = window;

export const Vote: FC = () => {
    const { state: voteList } = useVoteList();

    function goToVote(voteList: VoteList) {
        selfWindow.location = window.location + "/" + voteList.id;
    }

    function goToAwards(voteList: VoteList) {
        selfWindow.location = window.location + "/" + voteList.id + "/awards" ;
    }

    return (
        <div className="vote">
            <h1>Vote lists</h1>
            <div className="d-flex flex-wrap gap-3">

                {voteList?.map((v, i) =>
                    <Card key={i} className={"vote-list p-2 mt-3 bg-dark-green "} style={{ width: '18rem' }} >
                        <Card.Body>
                            <Card.Title>{v.name}</Card.Title>
                            <Card.Subtitle >Number of votes: <i>{v.numberOfVotes}</i></Card.Subtitle>
                            <Card.Text>
                                <div className="flex flex-column">
                                    <span>Number of books: <i>{v.numberOfBooks}</i></span>
                                    <span>Created at: <i>{moment(v.created).format('MMMM Do YYYY')}</i></span>
                                    <span>Created by: <i>{v.userId}</i></span>
                                </div>
                            </Card.Text>
                            <div className="d-flex flex-column">
                                <button onClick={() => goToVote(v)} className={"mt-2 btn btn-primary "}>
                                    Vote list
                                </button>
                                <button onClick={() => goToAwards(v)} className={"mt-2 btn btn-primary "}>
                                    Awards
                                </button>
                            </div>
                        </Card.Body>
                    </Card>
                )}
            </div>
        </div>
    );

}