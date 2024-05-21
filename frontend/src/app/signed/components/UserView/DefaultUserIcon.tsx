import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

import {
    SizeOptions,
    getUserCircleStyle,
    getUserIconStyle
} from './styleOptions';

interface DefaultUserIconProps {
    size: SizeOptions;
}

export default function DefaultUserIcon({ size }: DefaultUserIconProps) {
    const userCircleStyle = getUserCircleStyle(size);
    const userIconStyle = getUserIconStyle(size);

    return (
        <div className={userCircleStyle}>
            <FontAwesomeIcon className={userIconStyle} icon={faUser} />
        </div>
    );
}
