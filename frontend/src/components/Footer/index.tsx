import PaySysLogoRounded from '../PaySysLogoRounded';
import CopyrightText from './CopyrightText';

export default function Footer() {
    return (
        <div className="h-72 px-28 py-16 bg-gradient-to-t from-green-100 to-green-200">
            <div className="h-full flex flex-col justify-between">
                <PaySysLogoRounded />
                <CopyrightText />
            </div>
        </div>
    );
}
