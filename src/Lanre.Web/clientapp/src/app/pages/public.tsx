
import { ReactComponent as Logo } from '../../assets/images/books.svg';
import { useAuth } from "react-oidc-context";


export const Public = () => {
    const auth = useAuth();
    return <article >

        <main className=" text-center">
            <div className="row justify-content-center">
                <div className="col-md-12 col-lg-10">
                    <div className="wrap d-md-flex align-items-center">

                        <div className="login-wrap mt-5 p-4 p-md-5 w-50 ">
                            <><button onClick={() => void auth.signinRedirect()}>Log in</button></>
                        </div>
                        <Logo className="w-50"></Logo>
                        {/* <div className="img" style={{ backgroundImage: "url(images/xbg-1.jpg.pagespeed.ic.3OAd9jZTMD.webp)" }}>
                        </div> */}
                    </div>
                </div>
            </div>
        </main>
    </article>;
}