import PaySysLogoRounded from '../PaySysLogoRounded';
import CopyrightText from './CopyrightText';
import FooterSection from './FooterSection';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
    faFacebookF,
    faInstagram,
    faTwitter,
    faYoutube,
    faWhatsapp
} from '@fortawesome/free-brands-svg-icons';
import { faPhone } from '@fortawesome/free-solid-svg-icons';
import { faEnvelope } from '@fortawesome/free-regular-svg-icons';

export default function Footer() {
    return (
        <footer className="h-72 px-28 py-16 bg-gradient-to-t from-green-100 to-green-200 flex justify-between">
            <div className="h-full flex flex-col justify-between">
                <PaySysLogoRounded />
                <CopyrightText />
            </div>

            <FooterSection.Container>
                <FooterSection.Title>Redes Sociais</FooterSection.Title>
                <FooterSection.ItemsWrapper>
                    <FooterSection.Item
                        icon={
                            <FontAwesomeIcon
                                className="text-green-100 w-2"
                                icon={faFacebookF}
                            />
                        }
                        text="PaymentSystem"
                    />
                    <FooterSection.Item
                        icon={
                            <FontAwesomeIcon
                                className="text-green-100 w-3"
                                icon={faInstagram}
                            />
                        }
                        text="@PaySys"
                    />
                    <FooterSection.Item
                        icon={
                            <FontAwesomeIcon
                                className="text-green-100 w-3"
                                icon={faTwitter}
                            />
                        }
                        text="PaySysOficial"
                    />
                    <FooterSection.Item
                        icon={
                            <FontAwesomeIcon
                                className="text-green-100 w-3"
                                icon={faYoutube}
                            />
                        }
                        text="PaySystem"
                    />
                </FooterSection.ItemsWrapper>
            </FooterSection.Container>

            <FooterSection.Container>
                <FooterSection.Title>Contato</FooterSection.Title>
                <FooterSection.ItemsWrapper>
                    <FooterSection.Item
                        icon={
                            <FontAwesomeIcon
                                className="text-green-100 w-3 ml-px"
                                icon={faWhatsapp}
                            />
                        }
                        text="11 98775-4321"
                    />
                    <FooterSection.Item
                        icon={
                            <FontAwesomeIcon
                                className="text-green-100 w-2.5 ml-px"
                                icon={faPhone}
                            />
                        }
                        text="4559-4321"
                    />
                    <FooterSection.Item
                        icon={
                            <FontAwesomeIcon
                                className="text-green-100 w-3 ml-px"
                                icon={faEnvelope}
                            />
                        }
                        text="admin@paysys.com"
                    />
                    <FooterSection.Item
                        icon={
                            <FontAwesomeIcon
                                className="text-green-100 w-3 ml-px"
                                icon={faEnvelope}
                            />
                        }
                        text="support@paysys.com"
                    />
                </FooterSection.ItemsWrapper>
            </FooterSection.Container>
        </footer>
    );
}
