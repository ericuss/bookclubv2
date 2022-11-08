import { FC } from "react";
import { useVoteList } from "./useVoteList.hook";
import './index.css';
import { Card } from "react-bootstrap";

const selfWindow: Window = window;

export const Vote: FC = () => {
    const { state: voteList } = useVoteList();

    function goToDetails(id: string) {
        selfWindow.location = window.location + "/" + id;
    }

    return (
        <div className="vote">
            Vote lists
            {voteList?.map((v, i) => 
                    <Card key={i} className={"vote-list mt-3 border border-3 rounded "} style={{ width: '18rem' }}  onClick={() => goToDetails(v.id)}>
                        <Card.Body>
                            <Card.Title>{v.name}</Card.Title>
                            <Card.Subtitle ><i>{v.numberOfVotes}</i></Card.Subtitle>
                            <Card.Subtitle ><i>{v.userId}</i></Card.Subtitle>
                        </Card.Body>
                    </Card>
            )}
        </div>
    );

}