import PaySysLogoRounded from '../PaySysLogoRounded';
import CopyrightText from './CopyrightText';
import FooterSection from './FooterSection';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebookF } from '@fortawesome/free-brands-svg-icons';

export default function Footer() {
    return (
        <footer className="h-72 px-28 py-16 bg-gradient-to-t from-green-100 to-green-200 flex justify-between">
            <div className="h-full flex flex-col justify-between">
                <PaySysLogoRounded />
                <CopyrightText />
            </div>

            <FooterSection.Container>
                <FooterSection.Title>Redes Sociais</FooterSection.Title>
                <FooterSection.Item
                    icon={
                        <FontAwesomeIcon
                            className="text-green-100 w-2"
                            icon={faFacebookF}
                        />
                    }
                    text="PaymentSystem"
                />
            </FooterSection.Container>

            <FooterSection.Container>
                <FooterSection.Title>Contato</FooterSection.Title>
            </FooterSection.Container>
        </footer>
    );
}
