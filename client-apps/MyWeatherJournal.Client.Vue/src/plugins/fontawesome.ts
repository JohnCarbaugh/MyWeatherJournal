import { library as FontAwesomeLibrary }  from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

import {
    faUser,
    faBook,
    faTachometerAlt,
    faBell,
    faChartLine,
    faBookOpen,
    faUsers,
    faCloudSun,
    faBars
} from '@fortawesome/free-solid-svg-icons'

import {
    faGithub,
    faLinkedin
} from '@fortawesome/free-brands-svg-icons'

FontAwesomeLibrary.add(
    faUser,
    faBook,
    faTachometerAlt,
    faBell,
    faChartLine,
    faBookOpen,
    faUsers,
    faCloudSun,
    faBars,
    faGithub,
    faLinkedin,
)

export { FontAwesomeIcon }